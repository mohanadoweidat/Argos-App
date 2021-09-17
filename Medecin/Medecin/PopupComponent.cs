using System;
using System.Collections.Generic;
using System.Text;

namespace Medecin
{
        public interface PopupComponent
        {
            PopupType GetPopupType();
            void OnClosed();
        }
}
