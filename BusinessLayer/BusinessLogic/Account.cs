
using AutoMapper;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;

namespace BusinessLayer.b
{


 public class Account
    {
        public enum enAccountType { Provider = 1, Clinic = 2, Patient = 3 }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public short AccountProviderID_FK { get; set; }


        public Account(AccountRequestDTO account)
        {
            AccountID = account.AccountID;
            AccountName = account.AccountName;
            AccountProviderID_FK = account.AccountProviderID_FK;
        }

        public Account(AccountEntity account)
        {
            AccountID = account.AccountID;
            AccountName = account.AccountName;
            AccountProviderID_FK = account.AccountProviderID_FK;
        }
    }
 public class AccountServices
        {
        

           readonly IMapper _mapper;
        readonly IAccountRepository _repo;
        public AccountServices(IAccountRepository accountRepository,IMapper mapper)
        {
            _mapper = mapper;
            _repo = accountRepository;
        }

        public int AddNewAccount(Account acc) { return _repo.AddAccount(_mapper.Map<AccountEntity>(acc)); }
            public bool UpdateAccount(Account acc) { return _repo.UpdateAccount(_mapper.Map<AccountEntity>(acc)); }


        }
    
}
