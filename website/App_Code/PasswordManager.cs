using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;


/// <summary>
/// this class is responsible for all interaction of user passwords
/// SHA256 algorithm is used to store passwords in the database along with
/// salt for extra security.
/// </summary>
public class PasswordManager
{

    private String username;
    private String password;
   
	public PasswordManager(String username, String password)
	{
        this.username = username;
        this.password = password;
	}

    public  bool createNewAccount(){
        Credentials newPass = generateNewPassword();

        bool created = UserDao.createAccount(newPass); //send to db for saving, returns true if successful/false for unsuccessful
        
        return created; 
    }

    private Credentials generateNewPassword()
    {
        HashAlgorithm algorithm = new SHA256Managed(); //hashing algorithm used for passwords

        byte[] pass = createByteArrayFromString(password); //create byte array
        String salt = generateSalt(); //get different salt for each password
        byte[] saltArray = createByteArrayFromString(salt); //create byte array for salt

        byte[] passWithSalt = pass.Concat(saltArray).ToArray(); //concate both pass array and salt array

        String hashedPass = Convert.ToBase64String(algorithm.ComputeHash(passWithSalt)); //create hash from salt and convert to string for storing in db

        Credentials newPass = new Credentials(username, hashedPass, salt, "2"); //create credentails object to send to db for saving
        return newPass;
    }
    //this method generates a different salt value for each password using the system time
    private String generateSalt()
    {
        return System.DateTime.Now.Ticks.ToString();
    }
    //this method checks that passwords match in a login attempt
    public bool checkPassword()
    {
        Credentials userCredentials = UserDao.getUserCredentials(username);
        if (userCredentials != null)
        {
            byte[] dbPass = Convert.FromBase64String(userCredentials.getPassword());

            byte[] userPass = createByteArrayFromString(password);
            byte[] dbSalt = createByteArrayFromString(userCredentials.getSalt());

            byte[] userSaltedPass = userPass.Concat(dbSalt).ToArray();

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hasheduserPass = algorithm.ComputeHash(userSaltedPass);

            bool match = compareByteArrays(dbPass, hasheduserPass);

            return match;
        }
        else
        {
            return false;
        }
    }
    //this method compares byte arrays of stored password in db and user supplied password on login
    private bool compareByteArrays(byte[] dbPass, byte[] userSaltedPass)
    {
        if (dbPass.Length != userSaltedPass.Length)
        {
            return false;
        }
        for (int i = 0; i < dbPass.Length; i++)
        {
            if (dbPass[i] != userSaltedPass[i])
            {
                return false;
            }
        }
        return true;
    }
    //utility method to create a byte array from a string
    private byte[] createByteArrayFromString(String s)
    {
        return Encoding.UTF8.GetBytes(s);
    }
    //this method changes a user's password
    public bool changePassword()
    {
        Credentials newPassword = generateNewPassword();

        bool success = UserDao.changePassword(newPassword);

        return success;

    }
    
}