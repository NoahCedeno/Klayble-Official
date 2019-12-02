/// <summary>
/// MatchManager manages the main match loop, storing match data after a conclusion is reached, and
/// stores important info about the match, such as who won.
/// As well, a palette for the map is useful!
/// </summary>
public class MatchManager
{
    private MapPalette m_MapPalette;
    public MapPalette MapPalette { get => m_MapPalette; private set => m_MapPalette = value; }

    // TODO: Implement main game loop here!
}