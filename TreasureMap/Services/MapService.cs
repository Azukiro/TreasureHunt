using System.ComponentModel.DataAnnotations;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Validators;

namespace TreasureMap.Services;

/// <summary>
/// Service for the management of the map.
/// </summary>
public class MapService : IMapService
{
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

    #region Singleton

    private static MapService? _instance;

    public static MapService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MapService();
            }

            return _instance;
        }
    }

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

    #region BusinessLogic

    public bool IsInsideMap(Position position)
    {
        if(BoundingBox == null)
        {
            throw new BoundingMapNotSetException();
        }
        
        return position.X >= 0 && position.X < BoundingBox.Width && position.Y >= 0 && position.Y < BoundingBox.Height;
    }

    public void ValidateMap()
    {
        List<ValidationResult> validationResults = new List<ValidationResult>();
        validationResults.AddRange(
            Cells.SelectMany(c => ValidatorHelper.Validate(c, this)
            ));
        validationResults.AddRange(
            Adventurers.SelectMany(c => ValidatorHelper.Validate(c, this)
            ));

        if (validationResults.Count > 0)
        {
            throw new ValidationException(string.Join(", ", validationResults));
        }
    }


    public bool CanMoveAdventurer(Adventurer adventurer, Position potentialPosition)
    {
        var isInsideMap = IsInsideMap(potentialPosition);
        var adventurerOnCase = Adventurers.Where(a => a.Name != adventurer.Name)
            .Any(a => a.Position.X == potentialPosition.X && a.Position.Y == potentialPosition.Y);
        var canMove =
            Cells.FirstOrDefault(c => c.Position.X == potentialPosition.X && c.Position.Y == potentialPosition.Y)?.CanMoveTo() ?? false;
        return canMove && isInsideMap && !adventurerOnCase;
    }

    #endregion
}