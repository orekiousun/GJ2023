using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyBase {
   

   public void Death()
    {
      
        Destroy(gameObject);
    }
}
