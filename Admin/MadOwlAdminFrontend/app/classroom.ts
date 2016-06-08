import {Student} from './student';

export interface Classroom {
    Name: string;
    StepCount: number;
    PinCode: number;
    ContentUri: string;
    Students: Student[];
}