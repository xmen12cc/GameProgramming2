using System;
using Unity.Properties;
using UnityEngine;

namespace Unity.Behavior
{
    /// <summary>
    /// The base class for conditions used in Conditional and Abort nodes.
    /// </summary>
    [Serializable]
    public abstract class Condition
    {
        /// <summary>
        /// IsTrue checks if the implemented condition is true.
        /// </summary>
        /// <returns>The result of the condition.</returns>
        public abstract bool IsTrue();

        /// <summary>
        /// OnStart is called as a setup method for the Condition before it begins checking its logic.
        /// </summary>
        public virtual void OnStart() { }

        /// <summary>
        /// OnEnd is called as a cleanup method for the Condition after it completes its logic check.
        /// </summary>
        public virtual void OnEnd() { }
        
        /// <summary>
        /// The game object associated with the behavior graph.
        /// </summary>
        public GameObject GameObject => Graph.GameObject;
        
        /// <summary>
        /// The BehaviorGraph containing the node instance.
        /// </summary>
        [SerializeReference]
        internal BehaviorGraphModule Graph;
    }
}