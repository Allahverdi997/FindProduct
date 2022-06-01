using PITask.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Client.Delivery
{
    public static class DeliveryClass
    {
        public static DeliveryEnum SetDelivery(int distance,double size)
        {
            if (distance == 0 && (size > 0 || size < 1))
                return DeliveryEnum.Velosiped;
            else if(distance>0 && distance<=100 && (size > 1 && size <= 5))
                return DeliveryEnum.Motosiklet;
            else if (distance > 100 && distance <= 150 && (size > 5 && distance <= 10))
                return DeliveryEnum.MinikAvtomobili;
            else if (distance > 150 && distance <= 250 && (distance > 10 && distance <= 25))
                return DeliveryEnum.YukAvtomobili;
            else if (distance > 250 && distance <= 350 && (distance > 25 && distance <= 50))
                return DeliveryEnum.Qatar;
            else
                return DeliveryEnum.Teyyare;
        }
    }
}
