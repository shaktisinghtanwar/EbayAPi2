using EbaySdkLib.Services;
namespace EbaySdkLib
    {
    public class AccountService
        {
        public string Token { get;private set; }
        public AccountService(string token)
            {
            Token = token;
            FulfilmentPolicyService = new FulfilmentPolicyService(Token);
            ProgramService = new ProgramService(Token);
            PrivilegeService = new PrivilegeService(Token);
            SalesTaxService = new SalesTaxService(Token);
            PaymentpolicyService = new PaymentpolicyService(Token);
            ReturnPolicyService = new ReturnPolicyService(Token);
            }

        public FulfilmentPolicyService FulfilmentPolicyService { get; set; }
        public ProgramService ProgramService { get; set; }
        public PrivilegeService PrivilegeService { get; set; }
        public SalesTaxService SalesTaxService { get; set; }
        public PaymentpolicyService PaymentpolicyService { get; set; }
        public ReturnPolicyService ReturnPolicyService { get; set; }
        }
    }
