public class User
{
    public int ID { get; set; }
    public string Uname { get; set; }

    public User(int id, string uname)
    {
        ID = id;
        Uname = uname;
    }

}