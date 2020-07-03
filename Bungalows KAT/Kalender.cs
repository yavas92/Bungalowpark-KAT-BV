using System;
using System.Collections.Generic;
using System.Text;

namespace Bungalows_KAT
{
    class Kalender
    {
        // Properties
        public DateTime Dag { get; set; }

        private int[] volleBungalowIds = new int[0];
        public int[] VolleBungalowIds
        {
            get { return volleBungalowIds; }
            set { Array.Copy(value, volleBungalowIds, value.Length); }
        }
        private int[] klantBungalowIds = new int[0];
        public int[] KlantBungalowIds
        {
            get { return klantBungalowIds; }
            set { Array.Copy(value, klantBungalowIds, value.Length); }
        }

        // Constructor
        public Kalender(int[] bungalowIds, int[] klantIds, DateTime dag)
        {
            Array.Copy(bungalowIds, volleBungalowIds, bungalowIds.Length);
            Array.Copy(klantIds, klantBungalowIds, klantIds.Length);
            Dag = dag;
        }

        //Boeking toevoegen
        public bool BungalowToevoegen(int bungalowId, int klantId)
        {
            if (CheckIdInVolleBungalows(bungalowId) == -1)
                return false;

            Array.Resize(ref volleBungalowIds, volleBungalowIds.Length + 1);
            Array.Resize(ref klantBungalowIds, klantBungalowIds.Length + 1);

            volleBungalowIds[volleBungalowIds.Length - 1] = bungalowId;
            klantBungalowIds[klantBungalowIds.Length - 1] = klantId;

            return true;
        }

        //Boeking verwijderen
        public bool BungalowVerwijderen(int bungalowId)
        {
            int index = CheckIdInVolleBungalows(bungalowId);
            if (index != -1)
                return false;

            //Replace index with last
            volleBungalowIds[index] = volleBungalowIds[volleBungalowIds.Length - 1];
            klantBungalowIds[index] = klantBungalowIds[klantBungalowIds.Length - 1];

            //Remove last element
            Array.Resize(ref volleBungalowIds, volleBungalowIds.Length - 1);
            Array.Resize(ref klantBungalowIds, klantBungalowIds.Length - 1);
            return true;
        }

        //Return index of bungalow Id if available
        private int CheckIdInVolleBungalows(int bungalowId)
        {
            for (int i = 0; i < volleBungalowIds.Length; i++)
            {
                if (bungalowId == volleBungalowIds[i])
                    return i;
            }

            return -1;
        }
    }
}
