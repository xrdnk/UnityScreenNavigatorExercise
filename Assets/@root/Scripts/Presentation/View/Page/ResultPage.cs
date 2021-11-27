using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    /// <summary>
    /// リザルトページ
    /// </summary>
    public sealed class ResultPage : Page
    {
        [SerializeField] Button _button_EnterTitle;

        PageContainer _titlePageContainer;

        void Start()
        {
            _titlePageContainer = PageContainer.Find(PageContainerConstants.ExerciseScenePageContainerName);

            _button_EnterTitle
                .OnClickAsObservable()
                .Subscribe(_ => OnEnterTitleButtonClicked())
                .AddTo(this);
        }

        void OnEnterTitleButtonClicked()
        {
            _titlePageContainer.Push(PageConstants.TitlePagePrefab(), false);
        }
    }
}