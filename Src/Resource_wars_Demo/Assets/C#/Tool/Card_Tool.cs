using UnityEngine;
namespace Tool
{
    public enum Direction
    {
        X,
        Y
    }
    public static class Card_Tool
    {
        public static Vector3 LookAt(GameObject gameObject_1,GameObject gameObject_2,float direction=1,Direction benchmark = Direction.Y)
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

        public static void Draw_a_circle(float r, LineRenderer lineRenderer, float width = 1f)
        {
            Vector3 center = Vector3.zero;
            //Բ�İ뾶
            float radius = r;
            //������������Ϊ360��
            lineRenderer.positionCount = 360;
            //��LineRenderer�����ߵĿ�� ��Բ�Ŀ�� ��Ϊ0.04
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            //ÿһ�����һ����Բ�ϵ������
            for (int i = 0; i < 360; i++)
            {
                float x = center.x + radius * Mathf.Cos(i * Mathf.PI / 180f);
                float z = center.z + radius * Mathf.Sin(i * Mathf.PI / 180f);
                lineRenderer.SetPosition(i, new Vector3(x, z, 0));
            }
        }
    }
}

