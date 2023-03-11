using System;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePrerequisite : MonoBehaviour
{
    public bool prerequisite, prerequisite1, prerequisite2;


    public virtual bool PrerequisiteCheck()
    {
        return prerequisite && prerequisite1;
    }
}

public class SomeOtherPuzzleClass : PuzzlePrerequisite
{
    public override bool PrerequisiteCheck()
    {
        //other code
        return true;
    }
}

/*public class PlayerFOO : MonoBehaviour
{
    public Movement movement;
    public Health health;
    
    public void OnUpdate(float deltaTime)
    {
        movement.OnUpdate();
    }
}

public class SomeEnemy : MonoBehaviour
{
    public float moveDistance = 10;
    public Transform target;
    public bool CanMove()
    {
        float val = target.GetComponent<Player>().fov;
        Vector3 dirFromPlayerToEnemy = transform.position - target.position;
        if(Vector3.Distance(transform.position, target.position) <= moveDistance) &&
        !(Vector3.Angle(target.forward, dirFromPlayerToEnemy) < val);

    }

    private void Update()
    {
        if (!CanMove())
        {
            return;
        }
        //Move to player
    }
}*/