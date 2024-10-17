using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Services;

public interface IStateService
{
    /// <summary>
    ///  Add a cell to the map.
    /// </summary>
    /// <param name="cell"></param>
    void AddCell(Cell cell);
    
    /// <summary>
    /// Add an adventurer to the map.
    /// </summary>
    /// <param name="adventurer"></param>
    void AddAdventurer(Adventurer adventurer);
    
    /// <summary>
    /// Set the bounding map.
    /// </summary>
    /// <param name="boundingBox"></param>
    void SetBoundingBox(BoundingBox boundingBox);
    
    /// <summary>
    /// Get the cell at a position.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    Cell? GetCell(Position position);
    
    /// <summary>
    /// Get the cells on the map.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Cell> GetCells();
    
    /// <summary>
    /// Get the bounding map.
    /// </summary>
    /// <returns></returns>
    BoundingBox GetBoundingBox();
    
    /// <summary>
    /// Get the adventurers on the map.
    /// </summary>
    /// <returns></returns>
    List<Adventurer> GetAdventurers();
    
    /// <summary>
    /// Reset the state
    /// </summary>
    void Reset();
    
}