namespace ChainOfResponsibility
{
    class SupportRequest
    {
        public string IssueType { get; set; }

        public SupportRequest(string issueType)
        {
            IssueType = issueType;
        }
    }
    class BasicSupport : SupportHandler
    {
        public override bool Handle(SupportRequest request)
        {
            if (request.IssueType == "1")
            {
                Console.WriteLine("Basic Support: Ми допоможемо вам з простими питаннями.");
                return true;
            }
            else if (Next != null)
                return Next.Handle(request);

            return false;
        }
    }

    class TechnicalSupport : SupportHandler
    {
        public override bool Handle(SupportRequest request)
        {
            if (request.IssueType == "2")
            {
                Console.WriteLine("Technical Support: Розглядаємо ваше технічне питання.");
                return true;
            }
            else if (Next != null)
                return Next.Handle(request);

            return false;
        }
    }

    class BillingSupport : SupportHandler
    {
        public override bool Handle(SupportRequest request)
        {
            if (request.IssueType == "3")
            {
                Console.WriteLine("Billing Support: Вирішимо ваше питання з оплатою.");
                return true;
            }
            else if (Next != null)
                return Next.Handle(request);

            return false;
        }
    }

    class ManagerSupport : SupportHandler
    {
        public override bool Handle(SupportRequest request)
        {
            if (request.IssueType == "4")
            {
                Console.WriteLine("Менеджер: Підключаюсь для вирішення вашого питання.");
                return true;
            }
            else if (Next != null)
                return Next.Handle(request);

            return false;
        }
    }

}
