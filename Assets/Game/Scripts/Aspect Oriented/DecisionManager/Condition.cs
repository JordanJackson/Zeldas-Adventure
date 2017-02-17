using UnityEngine;
using System.Collections;

// a logical 'block' that can be evaluated
abstract public class Condition : MonoBehaviour {

	abstract public bool Evaluate();
}
