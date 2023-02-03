
public class MarsPlateau
{
    private string size;
    private int maxLatitude;
    private int maxLongitude;

    public MarsPlateau(string size)
    {
        this.size = size.ToLower();
        string[] splitedSize = this.size.Split('x');

        this.maxLatitude = Int32.Parse(splitedSize[0]);
        this.maxLongitude = Int32.Parse(splitedSize[1]);
    }

    public String getSize()
    {
        return this.size;
    }

    public Int32 getMaxLatitude()
    {
        return this.maxLatitude;
    }

    public Int32 getMaxLongitude()
    {
        return this.maxLongitude;
    }

    public bool validatePosition(int latitude, int longitude)
    {
        if (latitude > this.maxLatitude || longitude > this.maxLongitude)
        {
            return false;
        }

        return true;
    }
}
