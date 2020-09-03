using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//public interface IEatable
//{
//    void EatEvent();
//}
public class ItemComponet : MonoBehaviour
{
    public UnityEvent m_BeAteEvent;

    
   public void BeAte(Player player)
    {
        //아이템 이벤트 처리
        m_BeAteEvent.Invoke();

        if(player != null)
        player.LevelUp();
        


        //Destroy(gameObject);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
