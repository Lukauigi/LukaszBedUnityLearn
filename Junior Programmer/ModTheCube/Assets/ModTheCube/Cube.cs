using UnityEngine;

/// <summary>
/// Handler of the behaviour of the cube.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-17
/// </summary>
public class Cube : MonoBehaviour
{
    // Invoke repeat times.
    private readonly float _startDelay = 0;
    private readonly float _invokeInterval = 4f;
    // Index of current cube location.
    private int _locationIndex;
    // Rotation values all axises.
    private float _xAxisRotation;
    private float _yAxisRotation;
    private float _zAxisRotation;
    // Scale range of the cube.
    private readonly float _scaleLowerBound = 1;
    private readonly float _scaleUpperBound = 5;
    // Degrees of rotation range.
    private readonly float _rotationLowerBound = 0;
    private readonly float _rotationSpeedUpperBound = 180;
    // Colour components of material colour.
    private float _redComponent = 0.14f;
    private float _greenComponent = 0.33f;
    private float _blueComponent = 0.69f;
    private float _alphaComponent = 0.75f;
    // Colour increment/decrement toggles: increment is true, decrement is false.
    private bool _redIncrement = true;
    private bool _greenIncrement = true;
    private bool _blueIncrement = true;
    private bool _alphaIncrement = true;
    // Colour component range.
    private readonly float _minColorRange = 0;
    private readonly float _maxColorRange = 1;
    // Rate of which the cube's colour components change.
    private readonly float _colorComponentChangeRate = 0.07f;

    // Coordinates of various locations the cube teleports to.
    public Vector3[] locations;
    public MeshRenderer Renderer;
    
    void Start()
    {
        // Access & change the cube's colour.
        Material material = Renderer.material;
        RandomizeColor();
        material.color = new Color(_redComponent, _greenComponent, _blueComponent, _alphaComponent);

        RandomizeXYZRotation();
        // Randomize the cube's properties throughout intervals of its life
        InvokeRepeating(nameof(RandomizeCubeProperties), _startDelay, _invokeInterval);
    }
    
    void Update()
    {
        transform.Rotate(_xAxisRotation * Time.deltaTime, _yAxisRotation * Time.deltaTime, _zAxisRotation * Time.deltaTime);

        ProgressiveColorComponentChange(ref _redComponent, ref _redIncrement);
        ProgressiveColorComponentChange(ref _greenComponent, ref _greenIncrement);
        ProgressiveColorComponentChange(ref _blueComponent, ref  _blueIncrement);
        ProgressiveColorComponentChange(ref _alphaComponent, ref _alphaIncrement);
    }

    /// <summary>
    /// Randomzies various properties of the cube.
    /// 
    /// Date: 2023-02-17
    /// </summary>
    private void RandomizeCubeProperties()
    {
        // Teleports the cube to a new random location not the same as the last.
        _locationIndex = UniqueRandomIndex(_locationIndex, locations.Length);
        transform.position = locations[_locationIndex];
        // Changes cube's scale randomly.
        transform.localScale = UniqueRandom3DVector(transform.localScale);
        // Randomize the spin of the cube.
        RandomizeXYZRotation();
    }

    /// <summary>
    /// Returns a random index which is not the same as the given index.
    /// 
    /// Date: 2023-02-16
    /// </summary>
    /// <param name="originalIndex">A postitive non-zero integer; the current index.</param>
    /// <param name="size">A positive non-zero integer; size of array.</param>
    /// <returns>A random int not the same as the original index.</returns>
    private int UniqueRandomIndex(int originalIndex, int size)
    {
        int index;
        do
        {
            index = Random.Range(0, size);
        } while (index == originalIndex);

        return index;
    }

    /// <summary>
    /// Returns a random 3D vector which is not the same as the given 3D vector.
    /// 
    /// Date: 2023-02-16
    /// </summary>
    /// <param name="vector">A 3D vector.</param>
    /// <returns>A random Vector3 not the same as the given Vector3.</returns>
    private Vector3 UniqueRandom3DVector(Vector3 vector)
    {
        Vector3 newVector;
        do
        {
            newVector = Vector3.one * Random.Range(_scaleLowerBound, _scaleUpperBound);
        } while (newVector == vector);

        return newVector;
    }

    /// <summary>
    /// Edits the cube's degree of rotation on x, y, and z axis angles with random values.
    /// 
    /// Date: 2023-02-16
    /// </summary>
    private void RandomizeXYZRotation()
    {
        _xAxisRotation = Random.Range(_rotationLowerBound, _rotationSpeedUpperBound);
        _yAxisRotation = Random.Range(_rotationLowerBound, _rotationSpeedUpperBound);
        _zAxisRotation = Random.Range(_rotationLowerBound, _rotationSpeedUpperBound);
    }

    /// <summary>
    /// Randomizes the cube's colour component values.
    /// 
    /// Date: 2023-02-17
    /// </summary>
    private void RandomizeColor()
    {
        _redComponent = Random.Range(_minColorRange, _maxColorRange);
        _greenComponent = Random.Range(_minColorRange, _maxColorRange);
        _blueComponent = Random.Range(_minColorRange, _maxColorRange);
        _alphaComponent = Random.Range(_minColorRange, _maxColorRange);
    }

    /// <summary>
    /// Changes the given cube colour component colour slighty between min and max colour value ranges.
    /// 
    /// The colour component slightly increments until it reaches the maximum, then it will decrement 
    /// until it reaches the minimum value, and repeats this process. Minimum and maximum values are 
    /// 0 and 1 respectively. 
    /// 
    /// Date: 2023-02-17
    /// </summary>
    /// <param name="colorComponent">The reference to the colour component variable.</param>
    /// <param name="increment">The reference to the colour component's increment variable.</param>
    private void ProgressiveColorComponentChange(ref float colorComponent, ref bool increment)
    {
        // Increments or decrements based on the increment toggle.
        GradualColorComponentChange(ref colorComponent, increment);
        // Changes the increment toggle based.
        SetColourComponentIncrementToggle(colorComponent, ref increment);
        // Sets slightly changed cube colour.
        Renderer.material.color = new Color(_redComponent, _greenComponent, _blueComponent, _alphaComponent);
    }

    /// <summary>
    /// Changes the colour value of the component slightly by incrementing/decrementing it based on the passed
    /// 
    /// Date: 2023-02-17
    /// </summary>
    /// <param name="colorComponent">The reference to the colour component variable.</param>
    /// <param name="increment">The boolean value for whether to increment colour component's value.</param>
    private void GradualColorComponentChange(ref float colorComponent, bool increment)
    {
        if (increment) colorComponent += Time.deltaTime * _colorComponentChangeRate;
        else if (!increment) colorComponent -= Time.deltaTime * _colorComponentChangeRate;
    }

    /// <summary>
    /// Changes the increment toggle of given colour component if the colour component's value is beyond 
    /// a minimum or maximum threshold.
    /// 
    /// The minimum and maximum thresholds are 0 and 1 respectively.
    /// 
    /// Date: 2023-02-17
    /// </summary>
    /// <param name="colorComponent">The float value of the colour component.</param>
    /// <param name="increment">The reference to the colour component's increment variable.</param>
    private void SetColourComponentIncrementToggle(float colorComponent, ref bool increment)
    {
        if (colorComponent >= _maxColorRange) increment = false;
        else if (colorComponent <= _minColorRange) increment = true;
    }
}
