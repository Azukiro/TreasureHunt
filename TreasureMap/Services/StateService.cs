using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Services;

public class StateService : IStateService
{
    #region Singleton
    
    private static StateService? _instance;
    
    public static StateService Instance
    {
        get=> _instance ??= new StateService();
    }
    
    private StateService()
    {
    }
    
    #endregion
    
    #region Properties
    /// <summary>
    ///  The bounding box of the map.
    /// </summary>
    private BoundingBox? BoundingBox { get; set; }
    
    /// <summary>
    /// The cells on the map.
    /// </summary>
    private List<Cell> Cells { get; } = [];
    
    /// <summary>
    /// The adventurers on the map.
    /// </summary>
    private List<Adventurer> Adventurers { get; } = [];

    #endregion
    
    #region SetData

    public void AddAdventurer(Adventurer adventurer)
    {
        Adventurers.Add(adventurer);
    }
    public void AddCell(Cell cell)
    {
        Cells.Add(cell);
    }
    
    public void SetBoundingBox(BoundingBox boundingBox)
    {
        BoundingBox = boundingBox;
    }

    public void Reset()
    {
        BoundingBox = null;
        Cells.Clear();
        Adventurers.Clear();
    }
    
    #endregion

    #region GetData
    
    public BoundingBox GetBoundingBox()
    {
        return BoundingBox ?? throw new BoundingMapNotSetException();
    }
    
    public List<Adventurer> GetAdventurers()
    {
        return Adventurers;
    }

    public IEnumerable<Cell> GetCells()
    {
        return Cells;
    }
    
    public Cell? GetCell(Position position)
    {
        return Cells.FirstOrDefault(c => c.Position.X == position.X && c.Position.Y == position.Y);
    }
    #endregion
}