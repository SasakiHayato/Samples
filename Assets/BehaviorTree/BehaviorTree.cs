using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorAI
{
    public interface IBehavior
    {
        void Call(IAction set);
    }

    public interface IConditional
    {
        bool Check();
    }

    public interface IAction
    {
        void Execute();
        bool End();
        bool Reset { set; }
    }


    public class BehaviorTree : MonoBehaviour
    {
        enum State
        {
            Run,
            Set,

            None,
        }

        State _state = State.None;
        [SerializeField] List<Selector> _selector = new List<Selector>();

        [System.Serializable]
        public class Selector
        {
            public List<Seqence> Datas = new List<Seqence>();

            [System.Serializable]
            public class Seqence
            {
                [SerializeReference, SubclassSelector] 
                public IConditional Conditional;
                [SerializeReference, SubclassSelector] 
                public IAction Action;
            }
        }

        SelectorNode _stN;
        SequenceNode _sqN;

        public void Repeater<T>(T get) where T : IBehavior
        {
            switch (_state)
            {
                case State.Run:
                    _sqN.Set(_selector[_stN.GetID].Datas[_sqN.ID], get, ref _state);
                    break;
                case State.Set:
                    _state = State.None;
                    break;
                case State.None:
                    _stN = new SelectorNode();
                    _sqN = new SequenceNode();
                    _state = State.Set;
                    _stN.Set(_selector, _sqN, ref _state);
                    break;
            }     
        }

        class SelectorNode
        { 
            public int GetID { get => _id; }
            int _id = 0;

            public void Set(List<Selector> st, SequenceNode sq, ref State state)
            {
                ConditionalNode cN = new ConditionalNode();

                if (st.Count <= 0)
                {
                    Debug.LogError("データがありません");
                    return;
                }
                if (st.Count <= 1)
                {
                    _id = 0;
                    cN.Set(st[0], sq, ref state);
                }
                else
                {
                    // 乱数設定 : Note 改善の余地あり
                    int randomID = Random.Range(0, st.Count);
                    _id = randomID;
                    cN.Set(st[randomID], sq, ref state);
                }
            }
        }

        class ConditionalNode
        {
            public void Set(Selector st, SequenceNode sq, ref State state)
            {
                for (int id = 0; id < st.Datas.Count; id++)
                {
                    IConditional c = st.Datas[id].Conditional;
                    if (c.Check())
                    {
                        state = State.Run;
                        sq.ID = id;
                        return;
                    }
                }
                
                state = State.None;
            }
        }

        class SequenceNode
        {
            public int ID { get; set; } = 0;

            public void Set(Selector.Seqence sq, IBehavior b, ref State state)
            {
                ActionNode aN = new ActionNode();

                if (sq.Conditional.Check()) aN.Set(sq.Action, b, ref state);
                else
                {
                    sq.Action.Reset = false;
                    state = State.None;
                }
            }
        }

        class ActionNode
        { 
            public void Set(IAction a, IBehavior iB, ref State state)
            {
                if (a.End())
                {
                    state = State.None;
                    a.Reset = false;
                }
                else 
                    iB.Call(a);
            }
        }
    }
}
