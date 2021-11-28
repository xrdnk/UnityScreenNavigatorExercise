using System.Collections;
using Cysharp.Threading.Tasks;
using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    public sealed class LicenceModal : Modal
    {
        [SerializeField] Button _button_HideLicence;
        [SerializeField] AudioSource _audioSourceShowLicence;
        [SerializeField] AudioSource _audioSourceHideLicence;

        ModalContainer _modalContainer;

        public override IEnumerator WillPushEnter()
        {
            _audioSourceShowLicence.PlayOneShot(_audioSourceShowLicence.clip);
            Debug.Log("WillPushEnter@LicenceModal");
            yield break;
        }

        public override IEnumerator Cleanup()
        {
            _audioSourceHideLicence.PlayOneShot(_audioSourceHideLicence.clip);
            // オーディオ再生が終わるまで待つ
            yield return new WaitUntil(() => !_audioSourceHideLicence.isPlaying);
            Debug.Log("Cleanup@LicenceModal");
        }

        void Start()
        {
            _modalContainer = ModalContainer.Find(ModalContainerConstants.ExerciseSceneModalContainerName);

            _button_HideLicence
                .OnClickAsObservable()
                .Subscribe(_ => OnHideLicenceButtonClicked().Forget())
                .AddTo(this);
        }

        async UniTask OnHideLicenceButtonClicked()
        {
            await _modalContainer.Pop(true);
        }
    }
}