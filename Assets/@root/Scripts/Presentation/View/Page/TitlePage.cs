using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    /// <summary>
    /// タイトルページ
    /// </summary>
    public sealed class TitlePage : Page
    {
        [SerializeField] Button _button_EnterMain;

        PageContainer _titlePageContainer;

        void Start()
        {
            _titlePageContainer = PageContainer.Find(PageContainerConstants.ExerciseScenePageContainerName);

            _button_EnterMain
                .OnClickAsObservable()
                .Subscribe(_ => OnEnterMainButtonClicked())
                .AddTo(this);
        }

        void OnEnterMainButtonClicked()
        {
            // メインページ画面へPush遷移する
            _titlePageContainer
                .Push
                (
                    // メインページプレハブのキー
                    resourceKey: PageConstants.MainPagePrefab(),
                    // アニメーションを再生するかどうか
                    playAnimation: false,
                    // スタッキングを行うか,
                    stack: true,
                    // ロード時の処理
                    onLoad: null,
                    // 非同期ロードを行うかどうか
                    loadAsync: false
                );
        }
    }
}