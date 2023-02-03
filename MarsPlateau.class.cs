
public class MarsPlateau
{
    private string _size;
    private int _maxLatitude;
    private int _maxLongitude;

    public MarsPlateau(string size)
    {
        this._size = size.ToLower();
        string[] splitedSize = this._size.Split('x');

        this._maxLatitude = Int32.Parse(splitedSize[0]);
        this._maxLongitude = Int32.Parse(splitedSize[1]);
    }

    public String getSize()
    {
        return this._size;
    }

    public Int32 getMaxLatitude()
    {
        return this._maxLatitude;
    }

    public Int32 getMaxLongitude()
    {
        return this._maxLongitude;
    }

    public bool validatePosition(int latitude, int longitude)
    {
        if (latitude > this._maxLatitude || longitude > this._maxLongitude)
        {
            return false;
        }

        return true;
    }
}
