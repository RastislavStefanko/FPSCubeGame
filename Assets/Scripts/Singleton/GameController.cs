using System.Collections.Generic;
using UnityEngine;

public class GameController : GenericSingleton<GameController>
{

    public List<Transform> wayPoints;
    public Transform player;
    public int playerSpeed;
    public int spawningRedCount;
    public int cameraHight;

}
