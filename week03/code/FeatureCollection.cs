public class FeatureCollection
{
    // The JSON contains a "features" array. Each item is one earthquake event.
    public Feature[] Features { get; set; } = System.Array.Empty<Feature>();
}

// This class represents one item inside the "features" array
public class Feature
{
    // Each feature contains a "properties" object
    public Properties Properties { get; set; } = new Properties();
}

// This class represents the "properties" object for each earthquake
public class Properties
{
    // "place" is the location description string (example: "1km NE of ...")
    public string Place { get; set; } = "";

    // "mag" is the earthquake magnitude (strength). It can be null sometimes.
    public double? Mag { get; set; }
}