using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class AccountData : IAccountRepository
    {
        private readonly Clinicdbcontext _context;
        public AccountData(Clinicdbcontext context)
        {
            _context = context;

        }

        public  int AddAccount(AccountEntity account)
        {
            using (_context )
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return account.AccountID;
            }
        }

        public  bool UpdateAccount(AccountEntity account)
        {
            using (_context )
            {
                _context.Accounts.Update(account);
                return _context.SaveChanges() > 0;
            }
        }

        public  bool DeleteAccount(int accountId)
        {
            using (_context)
            {
                var account = _context.Accounts.Find(accountId);
                if (account == null) return false;
                _context.Accounts.Remove(account);
                return _context.SaveChanges() > 0;
            }
        }

        public  AccountEntity GetAccountById(int accountId)
        {
            using (_context )
            {
                return _context.Accounts.FirstOrDefault(x => x.AccountID == accountId);
            }
        }

        public  List<AccountEntity> GetAllAccounts()
        {
            using (_context)
            {
                return _context.Accounts.AsNoTracking().ToList();
            }
        }

    }
}
