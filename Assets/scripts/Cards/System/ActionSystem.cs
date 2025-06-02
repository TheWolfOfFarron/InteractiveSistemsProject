using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;

public class ActionSystem : Singeleton<ActionSystem>
{

    private List<GameAction> reactions = null;

    public bool isPerforming {  get; private set; } =false;

    private static Dictionary<Type, List<Action<GameAction>>> preSubs = new();
    private static Dictionary<Type, List<Action<GameAction>>> postSubs = new();
    private static Dictionary<Type, Func<GameAction, IEnumerator>> performers = new();


    public void Perform(GameAction action, System.Action OnPerformFinised = null)
    {
        if (isPerforming) return;
        isPerforming = true;
        StartCoroutine(Flow(action, () =>
        {
            isPerforming=false;
            OnPerformFinised?.Invoke();
        }));
    }
    

     public void AddReaction(GameAction action)
    {
        reactions?.Add(action);
    }
     
    private IEnumerator Flow(GameAction action, Action OnFlowFinised = null)
    {
        reactions= action.PreReactions;
        PerformSubscribers(action,preSubs);
        yield return PerformReaction();

        reactions = action.PerformReactions;
        yield return PerformPerformer(action);
        yield return PerformReaction();

        reactions=action.PostReactions;
        PerformSubscribers(action,postSubs);
        yield return PerformReaction();

        OnFlowFinised?.Invoke();


    }
  
    private IEnumerator PerformPerformer(GameAction action)
    {
        Type type = action.GetType();
        if(performers.ContainsKey(type))
        {
            yield return performers[type](action);
        }
    }

    private void PerformSubscribers(GameAction action, Dictionary<Type,List<Action<GameAction>>> subs)
    {
        Type type = action.GetType();
        if (performers.ContainsKey(type))
        {
           foreach(var sub in subs[type])
            {
                sub(action);
            }
        }
    }

    private IEnumerator PerformReaction()
    {
        foreach(var reaction in reactions)
        {
            yield return  Flow(reaction);
        }
    }

    public static void AttachPerformer<T>(Func<T,IEnumerator> performer) where T : GameAction
    {
        Type type = typeof(T);  
        IEnumerator wrapperPerformer(GameAction gameAction) => performer((T)gameAction);
        if (performers.ContainsKey(type)) performers[type] = wrapperPerformer;
        else performers.Add(type, wrapperPerformer);    
    }

    public static void DetachPerformer<T>()where T : GameAction
    {
        Type type= typeof(T);
        if(performers.ContainsKey(type)) performers.Remove(type);
    }

    public static void SubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
    {
        Dictionary<Type, List<Action<GameAction>>> subs =timing == ReactionTiming.PRE? preSubs : postSubs;
        void wrappedReaction(GameAction action) => reaction((T)action); 
        if(subs.ContainsKey(typeof(T)))
        {
            subs[typeof(T)].Add(wrappedReaction);   
        }
    }

    public static void UnsubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
    {
        Dictionary<Type, List<Action<GameAction>>> subs = timing == ReactionTiming.PRE ? preSubs : postSubs;
        if (subs.ContainsKey(typeof(T)))
        {
            void wrappedReaction(GameAction action)=> reaction((T)action);
            subs[typeof(T)].Remove(wrappedReaction);
        }

    }


}
