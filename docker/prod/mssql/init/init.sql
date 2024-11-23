IF NOT EXISTS(
    SELECT
        *
    FROM
        sys.databases
    WHERE
        name = 'StudyAspDotnetCore'
) BEGIN CREATE DATABASE StudyAspDotnetCore;

END
GO
