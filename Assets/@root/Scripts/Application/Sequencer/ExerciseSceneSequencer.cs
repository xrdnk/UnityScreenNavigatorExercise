using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer.Unity;

namespace Deniverse.UnityScreenNavigatorExercise.Application.Sequencer
{
    /// <summary>
    /// ExerciseScene における実行順番を制御するシーケンサークラス
    /// </summary>
    public sealed class ExerciseSceneSequencer : IStartable
    {
        PageContainer _titlePageContainer;

        void IStartable.Start()
        {
            EntryPoint();
        }

        void EntryPoint()
        {
            // PageContainer.Find は Start 以降ではないと正常に読み込まれない (Awake 以前だと null になる)
            _titlePageContainer = PageContainer.Find(PageContainerConstants.ExerciseScenePageContainerName);
            Assert.IsNotNull(_titlePageContainer);

            // 最初はタイトルページコンテナオブジェクトの子にタイトルページプレハブをプッシュする
            _titlePageContainer.Push
            (
                // タイトルページのプレハブのキー
                resourceKey: PageConstants.TitlePagePrefab,
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