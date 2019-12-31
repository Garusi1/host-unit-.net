

namespace BE
{

    public enum AreaEnum 
    {
        All,North,South,Center,Jerusalem
    }

    //enum SubArea
    //{
    //  Tel_Aviv
    //}

    public enum TypeEnum // type of hosting 
    {
        Zimmer,Hotel,Camping
    }
    public enum AttractionsEnum 
    {
        הכרחי,
        אפשרי,
        לא_מעוניין
    }

    public enum StatusEnum // status Order enum
    {
        טרם_טופל,
        נשלח_מייל,
        נסגר_מחוסר_הענות_הלקוח,
        נסגר_בהיענות_הלקוח
    }

    public enum StatusGREnum //Status for GuestRequest
    {
        פתוחה,
        נסגרה_עסקה_דרך_האתר,
        נסגרה_כי_פג_תוקפה
    }

}
