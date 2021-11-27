using Deniverse.UnityScreenNavigatorExercise.Application.Sequencer;
using VContainer;
using VContainer.Unity;

namespace Deniverse.UnityScreenNavigatorExercise.DIContainer
{
    public sealed class ExerciseSceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Sequencer
            builder.RegisterEntryPoint<ExerciseSceneSequencer>();
        }
    }
}