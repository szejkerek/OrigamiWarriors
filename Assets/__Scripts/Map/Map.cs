using System.Collections.Generic;
using System.Linq;

public class Map 
{
    public List<MapNode> mapNodes;
    public List<Point> path;
    public string configName;

    public Map(string configName, List<MapNode> mapNodes, List<Point> path)
    {
        this.mapNodes = mapNodes;
        this.path = path;
        this.configName = configName;
    }
    public MapNode GetNode(Point point)
    {
        return mapNodes.FirstOrDefault(n => n.locationOnMap.Equals(point));
    }

}
