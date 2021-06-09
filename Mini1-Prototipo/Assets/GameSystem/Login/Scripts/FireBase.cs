using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class FireBase : MonoBehaviour
{
    bool valid;
    public GameObject login;
    public GameObject regist;
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    void Awake()
    {
        valid = false;
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("No se han podido resovler las dependencias: " + dependencyStatus);
            }
        });
    }
    public bool GetValid() {
        return valid;
    }
    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
    }
    public void Loguear()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    public void Registrar()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            valid = false;
            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Comprueba el mail";
                    break;
                case AuthError.MissingPassword:
                    message = "Comprueba el pass";
                    break;
                case AuthError.WrongPassword:
                    message = "Pass incorrecto";
                    break;
                case AuthError.InvalidEmail:
                    message = "Email Invalido";
                    break;
                case AuthError.UserNotFound:
                    message = "Esta cuenta no existe";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            valid = true;
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Acceso Correcto";
            SceneManager.LoadScene(14);
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            valid = false;
            //If the username field is blank show a warning
            warningRegisterText.text = "Falta Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            valid = false;
            //If the password does not match show a warning
            warningRegisterText.text = "Los pass no coinciden";
        } 
        else if((passwordRegisterField.text== passwordRegisterVerifyField.text)&& passwordRegisterVerifyField.text.Length<6)
        {
            valid = false;
            warningRegisterText.text = "Introduce una contraseña de 6 carácteres o más";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                valid = false;
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Fallo en el registro!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Falta email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Falta Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email en uso";
                        break;
                }
                
                warningRegisterText.text = message;
            }
            else
            {
                
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    valid = true;
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        valid = false;
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        login.SetActive(true);
                        regist.SetActive(false);

                    }
                }
            }
        }
    }
}
