namespace TreasureMap.Services;

/// <summary>
///     Service for the simulation.
/// </summary>
public interface ISimulationService
{
   /// <summary>
   ///     Load a map.
   /// </summary>
   /// <param name="map"></param>
   void Load(string map);

   /// <summary>
   ///     Start the simulation.
   /// </summary>
   void Launch();

   /// <summary>
   ///     Save the game.
   /// </summary>
   void Save();
}