using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering.LookDev;

public class EnemyStateList : StatesList
{
    public const string IDLE = "ENEMY_IDLE";
    public const string CHASE = "ENEMY_CHASE";
    public const string ATTACK = "ENEMY_ATTACK";
    public const string CHASE_ATTACK = "ENEMY_CHASE_ATTACK";
    public const string PATROL = "ENEMY_PATROL";
    public const string ATTACK_RANGED = "ATTACK_RANGED";
}

