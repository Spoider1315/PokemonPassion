using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDatabase : MonoBehaviour
{
    public class Tackle : Move
    {
        public Tackle ()
        {
            this.Name = "Tackle";
            this.ThisType = Types.Normal;
            this.Form = "Physical";
            this.Power = 40;
            this.Accuracy = 100;
            this.PP = 35;
            this.MaxPP = 35;
        }
    }
    public class Sludge : Move
    {
        public Sludge()
        {
            this.Name = "Sludge";
            this.ThisType = Types.Poison;
            this.Form = "Special";
            this.Power = 65;
            this.Accuracy = 100;
            this.PP = 20;
            this.MaxPP = 20;
        }
    }
}
