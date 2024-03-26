import React, { useEffect, useState, ChangeEvent } from "react";
import { MuiTelInput } from "mui-tel-input";
import {
    Avatar,
    Box,
    TextField,
    Typography
} from '@mui/material';
import LockIcon from '@mui/icons-material/Lock';
const SignUp = () => {
    const [phone, setPhone] = useState();
    const [password, setPassword] = useState("");
    const [confirmpassword, setConfirmpassword] = useState("");
    const [matchpassword, setMatchPassword] = useState(true);

    const handlePhoneInputChange = (newValue: any) => {
        setPhone(newValue);
    };

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

    return (
        
        <Box sx={{ width: '350px', display: 'flex', flexDirection: 'column', gap: 2 , margin: 'auto', alignItems: 'center'}}>
          
            <Avatar sx={{ m: 'auto', bgcolor: 'secondary.main' }}>
                <LockIcon/>
            </Avatar>
            <Typography component="h1" variant="h5">
                Sign Up
           </Typography>
            <TextField
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
            />
            <TextField
                label="Email"
                name="email"
                type="email"
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
        </Box>
    );
}

export default SignUp;
