using Model.Model;
using Model.Model.Transactions;

namespace ViewModel.Transactions
{
    public class AccountHeadViewModel : BaseViewModel<AccountHead>
    {
        public AccountHeadViewModel(AccountHead x) : base(x)
        {
            Name = x.Name;
            this.AccountHeadType = x.AccountHeadType.ToString();
        }

        public string AccountHeadType { get; set; }

        public string Name { get; set; }
    }
}