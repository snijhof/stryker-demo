namespace Test;

public class Book
{
    private readonly int pages;
    private readonly string writer;

    public Book(int pages, string writer)
    {
        this.pages = pages;
        this.writer = writer;
    }

    public int CurrentPage { get; private set; } = 0;

    public void TurnPage()
    {
        CurrentPage++;
    }

    public void TurnBackPage()
    {
        CurrentPage--;
    }
}
