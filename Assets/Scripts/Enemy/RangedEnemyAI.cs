using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RangedEnemyAI: EnemyAI
{

    protected override void SetupFSM()
    {
        movementFsm = new EnemyMovementSM(this);
        movementFsm.Init();
        attackFsm = new EnemyAttackSM(this);
        attackFsm.Init();
    }
}

