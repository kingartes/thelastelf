using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EnemyChaseAttack : CombinedState
{
    public EnemyChaseAttack(EnemyChase enemyChase, EnemyAttack enemyAttack) : base(EnemyStateList.CHASE_ATTACK, new List<State> { enemyChase, enemyAttack })
    {
    }


}

