using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

public class GlobalEventManager
{
    public static event Action onEnemyKilled;

    public static void SendEnemyKilled()
    {
       if(onEnemyKilled != null) onEnemyKilled.Invoke();
    }

}

