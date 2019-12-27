namespace AliceInventory.Logic
{
    public enum ProcessingResultType
    {
        GreetingRequested,
        Declined,
        InvalidCount,
        Added,
        AddedMany,
        AddCanceled,
        Deleted,
        DeleteCanceled,
        Multiplied,
        MultiplyCanceled,
        Divided,
        DivisionCanceled,
        AllExceptDeleted,
        ClearRequested,
        Cleared,
        ListRead,
        ItemRead,
        MailSent,
        RequestedMail,
        ShowMail,
        MailAdded,
        MailDeleted,
        HelpRequested,
        Error,
        Exception,
        ExitRequested,
    }
}