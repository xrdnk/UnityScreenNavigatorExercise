using System.Collections;
using Cysharp.Threading.Tasks;
using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UniRx;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    /// <summary>
    /// タイトルページ
    /// </summary>
    public sealed class TitlePage : Page
    {
        [SerializeField] Button _button_EnterMain;
        [SerializeField] Button _button_ShowLicence;

        PageContainer _pageContainer;
        ModalContainer _modalContainer;

        public override IEnumerator Initialize()
        {
            _pageContainer = PageContainer.Find(PCConstants.ExerciseScenePageContainerName);
            _modalContainer = ModalContainer.Find(MCConstants.ExerciseSceneModalContainerName);

            _button_EnterMain
                .OnClickAsObservable()
                .Subscribe(_ => OnEnterMainButtonClicked())
                .AddTo(this);

            _button_ShowLicence
                .OnClickAsObservable()
                .Subscribe(_ => OnShowLicenceButtonClicked().Forget())
                .AddTo(this);

            yield break;
        }

        void OnEnterMainButtonClicked()
        {
            // メインページ画面へPush遷移する
            _pageContainer
                .Push
                (
                    // メインページプレハブのキー
                    resourceKey: PageConstants.LoadingMainPagePrefab,
                    // アニメーションを再生するかどうか
                    playAnimation: true,
                    // スタッキングを行うか,
                    stack: false,
                    // ロード時の処理
                    onLoad: null,
                    // 非同期ロードを行うかどうか
                    loadAsync: false
                );
        }

        async UniTask OnShowLicenceButtonClicked()
        {
            await _modalContainer
                .Push
                (
                    ModalConstants.LicenceModalPrefab,
                    true,
                    loadAsync: false
                );
        }

        public override IEnumerator WillPopEnter()
        {
            Debug.Log("WillPopEnter@TitlePage");
            yield break;
        }
    }
}