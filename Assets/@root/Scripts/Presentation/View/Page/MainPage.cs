using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    /// <summary>
    /// メインページ
    /// </summary>
    public sealed class MainPage : Page
    {
        [SerializeField] Button _button_EnterResult;
        [SerializeField] Button _button_ReturnTitle;

        PageContainer _titlePageContainer;

        void Start()
        {
            _titlePageContainer = PageContainer.Find(PageContainerConstants.ExerciseScenePageContainerName);

            _button_EnterResult
                .OnClickAsObservable()
                .Subscribe(_ => OnEnterResultButtonClicked())
                .AddTo(this);

            _button_ReturnTitle
                .OnClickAsObservable()
                .Subscribe(_ => OnReturnTitleButtonClicked())
                .AddTo(this);
        }

        void OnEnterResultButtonClicked()
        {
            _titlePageContainer.Push(PageConstants.ResultPagePrefab(), false);
        }

        void OnReturnTitleButtonClicked()
        {
            _titlePageContainer.Pop(false);
        }
    }
}