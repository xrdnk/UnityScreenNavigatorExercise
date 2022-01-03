using System.Collections;
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

        public override IEnumerator Initialize()
        {
            _titlePageContainer = PageContainer.Find(PCConstants.ExerciseScenePageContainerName);

            _button_EnterTitle
                .OnClickAsObservable()
                .Subscribe(_ => OnEnterTitleButtonClicked())
                .AddTo(this);

            yield break;
        }

        void OnEnterTitleButtonClicked()
        {
            _titlePageContainer.Pop(false);
            // _titlePageContainer.Push(PageConstants.TitlePagePrefab, false, false);
        }
    }
}