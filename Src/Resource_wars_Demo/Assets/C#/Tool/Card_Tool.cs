using UnityEngine;
namespace Tool
{
    public enum Direction
    {
        X,
        Y
    }
    public class Card_Tool
    {
        public Vector3 LookAt(GameObject gameObject_1,GameObject gameObject_2,float direction=1,Direction benchmark = Direction.Y)
        {
            if (benchmark == Direction.Y)
            {
                gameObject_1.transform.up = (gameObject_2.transform.position - gameObject_1.transform.position).normalized*direction;
            }
            else if (benchmark == Direction.X)
            {
                gameObject_1.transform.right = (gameObject_2.transform.position - gameObject_1.transform.position).normalized*direction;
            }
            return (gameObject_2.transform.position - gameObject_1.transform.position).normalized * direction;
        }
    }
}

