using UnityEngine;

namespace GPP
{
    public class ShopLinePoint : CurvedLinePoint
    {     
        public bool isShopConnection;
        public Color shopConnectionColor = Color.white;
        void OnDrawGizmos()
        {
            if( showGizmo == true )
            {
                if(isShopConnection){
                    Gizmos.color = shopConnectionColor;

                    Gizmos.DrawSphere( this.transform.position, gizmoSize );
                }else{
                    Gizmos.color = gizmoColor;

                    Gizmos.DrawSphere( this.transform.position, gizmoSize );
                }
            }
        }
    }
}