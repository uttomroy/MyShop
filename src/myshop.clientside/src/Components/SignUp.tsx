import React, { useEffect, useState, ChangeEvent, FormEvent } from "react";
import { MuiTelInput } from "mui-tel-input";
import {
    Avatar,
    Box,
    Button,
    TextField,
    Typography
} from '@mui/material';
import LockIcon from '@mui/icons-material/Lock';
const SignUp = () => {
    const [email, setEmail] = useState("")
    const [phone, setPhone] = useState();
    const [password, setPassword] = useState("");
    const [emailError, setEmailError] = useState(false);
    const [confirmpassword, setConfirmpassword] = useState("");
    const [matchpassword, setMatchPassword] = useState(true);

    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const email = event.target.value;
        setEmail(email);
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (emailPattern.test(email)) {
            setEmailError(false);
        } else {
            setEmailError(true);
        }
    }
    
    const handlePhoneInputChange = (newValue: any) => {
        setPhone(newValue);
    };
    const passwordStrength = (password: string ) => {

        const minLength = 8;
        const hasUppercase = /[A-Z]/.test(password);
        const hasLowercase = /[a-z]/.test(password);
        const hasSpecialChar= /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(password);
        const hasNumber = /[0-9]/
        let strength = "Weak" ;
        if( password.length > minLength && hasLowercase && hasUppercase && hasSpecialChar && hasNumber ){
            strength = "Strong" ;
        }
        else if (password.length >= minLength && (hasUppercase || hasLowercase || hasNumber || hasSpecialChar)) {
            strength = "Moderate";
        }
        return strength ;
    }
    const handlePasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
        const newPassword = event.target.value;
        setPassword(newPassword);
        setMatchPassword(() => newPassword === confirmpassword );
    };

    const handleConfirmPasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
        const newConfirmPassword = event.target.value;
        setConfirmpassword(newConfirmPassword);
        setMatchPassword(() => password === newConfirmPassword );
    };

    useEffect(() => {
        setMatchPassword(password === confirmpassword);
    }, [password, confirmpassword]);

    const handleSubmit = async (event: FormEvent) => {
        event.preventDefault();
        console.log("Form submitted!");
        
    };
    
    return (
        
        <form onSubmit={handleSubmit}>
            <Box sx={{ width: '350px', display: 'flex', flexDirection: 'column', gap: 2 , margin: 'auto', alignItems: 'center'}}>
          
                <Avatar sx={{ m: 'auto', bgcolor: 'secondary.main' }}>
                    <LockIcon/>
                </Avatar>
                <Typography component="h1" variant="h5">
                    Sign Up
                </Typography>
                {/* <TextField
                    label="First Name"
                    name="firstname"
                    fullWidth
                    required
                />
                <TextField
                    label="Last Name"
                    name="lastname"
                    fullWidth
                    required
                />
                <TextField
                    label="Login Name"
                    name="login-name"
                    fullWidth
                    required
                /> */}
                <TextField
                    label="Email"
                    name="email"
                    value={email}
                    onChange={handleEmailChange}
                    inputProps={{
                        type : "email",
                    }}
                    error = {emailError}
                    helperText =  { emailError ? "Please enter a valid email": ""} 
                    fullWidth
                    required
                />
                <MuiTelInput
                    placeholder="Enter phone number"
                    defaultCountry="BD"
                    fullWidth
                    value={phone}
                    onChange={handlePhoneInputChange}
                />
                <TextField
                    label="Password"
                    name="password"
                    type="password"
                    fullWidth
                    value={password}
                    onChange={handlePasswordChange}
                />
                
                <TextField
                    label="Confirm Password"
                    name="confirmPassword"
                    type="password"
                    fullWidth
                    value={confirmpassword}
                    onChange={handleConfirmPasswordChange}
                    error={!matchpassword}
                    helperText={!matchpassword && "Passwords do not match"}
                />
                <Typography variant="body2">
                    Password Strength: {password ? passwordStrength(password) : ""}
                </Typography>
                <Button type="submit" variant="contained" color="success">
                    Submit
                </Button>

            </Box>
        </form>
    );
}

export default SignUp;
