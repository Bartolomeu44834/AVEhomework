
public class Account {
    public static readonly int CODE = 4342;
    [ToLog()]
    public long balance;
    public Account(long b) { balance = b; }
}