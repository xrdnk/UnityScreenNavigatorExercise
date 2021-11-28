using System.Collections;
using TMPro;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    public class SampleSheet : Sheet
    {
        [SerializeField] TextMeshProUGUI _text_SheetName;

        const string SheetName = "Sheet_{0}";

        public void Setup(int index)
        {
            Identifier = $"{nameof(SampleSheet)}{index}";
            _text_SheetName.text = string.Format(SheetName, index);
        }

        public override void DidEnter()
        {
            Debug.Log("DidEnter@SampleSheet");
        }

        public override IEnumerator WillExit()
        {
            Debug.Log("WillExit@SampleSheet");
            yield break;
        }
    }
}