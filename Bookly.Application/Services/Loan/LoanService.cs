using Bookly.Application.Model;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;

namespace Bookly.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LoanService(ILoanRepository loanRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<int> Create(LoanInputModel inputModel)
        {
            User? user = await _userRepository.FindByIdAsync(inputModel.IdUser);
            Book? book = await _bookRepository.FindByIdAsync(inputModel.IdBook);

            if (user is null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            if (book is null)
            {
                throw new Exception("Livro não encontrado.");
            }

            Loan loan = new Loan(book.Id, user.Id, inputModel.DueDate.Value);
            book.Loan();

            await _bookRepository.UpdateAsync(book);
            int idLoan = await _loanRepository.CreateAsync(loan);
            return idLoan;
        }

        public async Task<LoanViewModel?> GetById(int idLoan)
        {
            Loan? loan = await _loanRepository.GetLoanAsync(idLoan);
            if (loan is null)
            {
                return null;
            }

            return new LoanViewModel(loan.Book.Title, loan.User.Name,
                loan.LoanDate, loan.DueDate, loan.ReturnDate);
        }

        public async Task<LoanViewModel?> ReturnLoan(int idLoan)
        {
            Loan? loan = await _loanRepository.GetLoanAsync(idLoan);
            if (loan is null)
            {
                return null;
            }

            loan.ReturnLoan();
            loan.Book.ReturnLoan();

            await _bookRepository.UpdateAsync(loan.Book);
            await _loanRepository.UpdateAsync(loan);

            return new LoanViewModel(loan.Book.Title, loan.User.Name,
                loan.LoanDate, loan.DueDate, loan.ReturnDate);
        }

        public async Task<List<LoanViewModel>> GetAll(bool active)
        {
            var list = await _loanRepository.GetAllAsync(active);
            return list.Select(reg => new LoanViewModel(reg.Book.Title, reg.User.Name,
                reg.LoanDate, reg.DueDate, reg.ReturnDate)).ToList();
        }
    }
}