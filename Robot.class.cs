public class Robot
{
    MarsPlateau marsPlateau;
    int latitude;
    int longitude;
    string itIsFacing;

    public Robot(MarsPlateau marsPlateau)
    {
        this.marsPlateau = marsPlateau;
        this.latitude = 1;
        this.longitude = 1;
        this.itIsFacing = "North";
    }

    public String move(string commands)
    {
        char[] splitedCommands = commands.ToUpper().ToCharArray(0, commands.Length);
        int latitude = this.latitude;
        int longitude = this.longitude;
        string itIsFacing = this.itIsFacing;

        foreach (char command in splitedCommands)
        {
            switch (command)
            {
                case 'L':
                {
                    switch (itIsFacing)
                    {
                        case "North":
                            itIsFacing = "West";
                        break;
                        case "South":
                            itIsFacing = "East";
                        break;
                        case "East":
                            itIsFacing = "North";
                        break;
                        case "West":
                            itIsFacing = "South";
                        break; 
                    }
                }
                break;
                case 'R':
                {
                    switch (itIsFacing)
                    {
                        case "North":
                            itIsFacing = "East";
                        break;
                        case "South":
                            itIsFacing = "West";
                        break;
                        case "East":
                            itIsFacing = "South";
                        break;
                        case "West":
                            itIsFacing = "North";
                        break; 
                    }
                }
                break;
                case 'F':
                {
                    switch (itIsFacing)
                    {
                        case "North":
                            latitude++;
                            if(latitude == 0)
                            {
                                latitude++;
                            }
                        break;
                        case "South":
                            latitude--;
                            if(latitude == 0)
                            {
                                latitude--;
                            }
                        break;
                        case "West":
                            longitude++;
                            if(longitude == 0)
                            {
                                longitude++;
                            }
                        break; 
                        case "East":
                            longitude--;
                            if(longitude == 0)
                            {
                                longitude--;
                            }
                        break;
                    }
                }
                break;
                default:
                    throw new WrongCommandException("("+command+") Unknown command");
            }
        }
        
        this.latitude = latitude;
        this.longitude = longitude;

        if(!this.marsPlateau.validatePosition(latitude, longitude))
        {
            throw new WrongCommandException("Moviment out of range");
        }

        return "It's located on: " + latitude.ToString() + ',' + longitude.ToString() + ',' + this.getZone(null, null);
    }

    protected String getZone(int? latitude, int? longitude)
    {
        string zone = "Middle";

        if(latitude is null)
        {
            latitude = this.latitude;
        }
        if(longitude is null)
        {
            longitude = this.longitude;
        }

        if(latitude == 1 && longitude == 1)
        {
            return zone;
        }

        if(latitude == 1)
        {
            if(longitude > 0)
            {
                zone = "East";
            }
            else if(longitude < 0)
            {
                zone = "West";
            }
        }
        else if(longitude == 1)
        {
            if(latitude > 0)
            {
                zone = "North";
            }
            else if(latitude < 0)
            {
                zone = "South";
            }
        }
        else if(latitude > 0 && longitude > 0)
        {
            zone = "Northest";
        }
        else if(latitude < 0 && longitude < 0)
        {
            zone = "Southwest";
        }
        else if(latitude < 0 && longitude > 0)
        {
            zone = "Southeast";
        }
        else if(latitude > 0 && longitude < 0)
        {
            zone = "Northwest";
        }

        return zone;
    }
}